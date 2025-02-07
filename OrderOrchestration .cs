using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessingFunctionApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using KhumalocraftEmporium_ST10069127_CLDV6211POE.Hubs;

namespace OrderProcessingFunctionApp
{
    public static class OrderOrchestration
    {
        [Function(nameof(OrderOrchestration))]
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            ILogger logger = context.CreateReplaySafeLogger(nameof(OrderOrchestration));
            logger.LogInformation("Starting Order Processing Orchestration...");

            var orderDetails = context.GetInput<Order>();

            // Step 1: Update Inventory
            await context.CallActivityAsync(nameof(UpdateInventory), orderDetails);

            // Step 2: Process Payment
            var paymentSuccess = await context.CallActivityAsync<bool>(nameof(ProcessPayment), orderDetails);

            if (!paymentSuccess)
            {
                await context.CallActivityAsync(nameof(SendNotification), $"Payment failed for Order ID {orderDetails.Id}. Please try again.");
                return;
            }

            // Step 3: Confirm Order
            await context.CallActivityAsync(nameof(ConfirmOrder), orderDetails);

            // Step 4: Send Push Notification to User
            await context.CallActivityAsync(nameof(SendNotification), $"Your order (ID: {orderDetails.Id}) has been placed successfully!");

            // Step 5: Send Order Dispatch Notification
            await context.CallActivityAsync(nameof(SendNotification), $"Your order (ID: {orderDetails.Id}) is being dispatched!");
        }

        [Function(nameof(UpdateInventory))]
        public static async Task UpdateInventory([ActivityTrigger] Order order, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(UpdateInventory));
            logger.LogInformation($"Updating inventory for Order ID: {order.Id}");

            await Task.Delay(2000); // Simulated inventory update

            logger.LogInformation($"Inventory updated successfully for Order ID: {order.Id}");
        }

        [Function(nameof(ProcessPayment))]
        public static async Task<bool> ProcessPayment([ActivityTrigger] Order order, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(ProcessPayment));
            logger.LogInformation($"Processing payment for Order ID: {order.Id}");

            await Task.Delay(3000); // Simulated payment processing

            bool paymentSuccess = true;
            logger.LogInformation($"Payment status for Order ID {order.Id}: {paymentSuccess}");
            return paymentSuccess;
        }

        [Function(nameof(ConfirmOrder))]
        public static async Task ConfirmOrder([ActivityTrigger] Order order, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(ConfirmOrder));
            logger.LogInformation($"Confirming order for Order ID: {order.Id}");

            await Task.Delay(1500); // Simulated confirmation process

            logger.LogInformation($"Order confirmed successfully for Order ID: {order.Id}");
        }

        [Function(nameof(SendNotification))]
        public static async Task SendNotification([ActivityTrigger] string message, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger(nameof(SendNotification));
            logger.LogInformation($"Sending notification: {message}");

            try
            {
                // Get SignalR service from dependency injection
                var hubContext = executionContext.InstanceServices.GetService<IHubContext<OrderHub>>();

                if (hubContext != null)
                {
                    await hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", message);
                    logger.LogInformation($"Notification sent successfully: {message}");
                }
                else
                {
                    logger.LogError("SignalR HubContext not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error sending notification: {ex.Message}");
            }
        }


        [Function("OrderProcessing_HttpStart")]
        public static async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("OrderProcessing_HttpStart");

            var order = await req.ReadFromJsonAsync<Order>();
            if (order == null)
            {
                var badRequest = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                await badRequest.WriteStringAsync("Invalid order data.");
                return badRequest;
            }

            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(nameof(OrderOrchestration), order);
            logger.LogInformation($"Started order workflow with ID: {instanceId}");

            var response = client.CreateCheckStatusResponse(req, instanceId);
            return response;
        }
    }
}
