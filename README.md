#🛍️ KhumaloCraft Emporium - E-Commerce Web App
An Elegant Marketplace for Unique Crafts & Custom Work
Welcome to KhumaloCraft Emporium, a fully functional E-Commerce Web App designed to offer a seamless shopping experience for craft lovers, artisans, and digital creators. This project integrates modern web development technologies with cloud-based services, ensuring secure transactions, real-time updates, and efficient order processing.

🌟 Features & Implementations
1️⃣ Web Application (ASP.NET Core MVC)
✅ Built using ASP.NET Core MVC for a structured, scalable architecture.
✅ Database integration via SQL Server for product & order management.
✅ Entity Framework Core for efficient data handling and migrations.
✅ Secure authentication & authorization using Identity Framework.
✅ SignalR Integration for real-time notifications.
✅ Custom User Profiles with order history & saved crafts.
✅ Intuitive UI/UX with modern styling and dynamic product galleries.

2️⃣ Order Processing System (Azure Durable Functions)
✅ Implemented Durable Functions for step-by-step order processing:

Inventory Updates
Payment Processing
Order Confirmation
Push Notifications to Users via SignalR
✅ Connected to the KhumaloCraft Web App for seamless interaction.
✅ Hosted via Azure Functions for scalability and reliability.
3️⃣ Shopping & Checkout System
✅ Interactive "Add to Cart" & "Save Crafts" functionality.
✅ Secure Payment Gateway Integration (Future Implementation).
✅ Order status tracking with real-time notifications.

4️⃣ Tech Stack
Frontend: ASP.NET Core MVC, Razor Pages, Bootstrap
Backend: C#, .NET 8, Entity Framework Core, Azure Durable Functions
Database: SQL Server (with EF Core Migrations)
Cloud Services: Azure Functions, Azure SignalR
Version Control: Git & GitHub
🚀 How to Run the Web App Locally
1️⃣ Clone the repository:

bash
Copy
Edit
git clone https://github.com/casbyhexer/KhumaloCraft_ECOM_CLDV6211POE.git
cd KhumaloCraft_ECOM_CLDV6211POE
2️⃣ Navigate to the Part2 (Web App) branch:

bash
Copy
Edit
git checkout Part2
3️⃣ Open the project in Visual Studio and ensure all dependencies are installed.

4️⃣ Update the appsettings.json with your SQL Server connection string:

json
Copy
Edit
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=KhumaloCraftDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
5️⃣ Apply any pending migrations:

powershell
Copy
Edit
dotnet ef database update
6️⃣ Run the application:

powershell
Copy
Edit
dotnet run
📦 Order Processing with Azure Durable Functions
1️⃣ Navigate to the Part3 (Order Processing) branch:

bash
Copy
Edit
git checkout Part3
2️⃣ Open the OrderProcessingFunctionApp in Visual Studio.

3️⃣ Ensure Azure Functions Core Tools is installed:

bash
Copy
Edit
npm install -g azure-functions-core-tools@4 --unsafe-perm true
4️⃣ Run the Azure Function locally:

powershell
Copy
Edit
func start
5️⃣ Test the Order Processing API:

powershell
Copy
Edit
curl -X POST "http://localhost:7071/api/OrderProcessing_HttpStart" -H "Content-Type: application/json" -d '{ "id": 1, "products": [{"name": "Handmade Vase", "quantity": 2}], "total": 150.00 }'
📢 Future Enhancements
🔹 Complete Payment Gateway Integration (PayPal, Stripe, or Direct Bank Transfer).
🔹 Admin Dashboard for Product Management & Order Tracking.
🔹 AI-Powered Craft Recommendations Based on User Preferences.
🔹 Multi-Language Support for a Global Audience.
🔹 Mobile App Version for Android & iOS.

🤝 Contributing
Interested in contributing to KhumaloCraft Emporium? Feel free to fork the repository, submit issues, and create pull requests.

📜 License
This project is open-source and available under the MIT License.

📞 Contact
For any inquiries, feature requests, or collaborations, reach out via:

📧 Email: [Your Email]
🌐 GitHub: @casbyhexer

🚀 Happy Coding & Crafting! 🚀
