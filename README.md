🛍️ KhumaloCraft Emporium - E-Commerce Web App
An Elegant Marketplace for Unique Crafts & Custom Work
Welcome to KhumaloCraft Emporium, a fully functional E-Commerce Web App designed to offer a seamless shopping experience for craft lovers, artisans, and digital creators. This project integrates modern web development technologies with secure transactions, real-time updates, and efficient order processing.

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
Component	Technology Used
Frontend	ASP.NET Core MVC, Razor Pages, Bootstrap
Backend	C#, .NET 8, Entity Framework Core, Azure Durable Functions
Database	SQL Server (with EF Core Migrations)
Cloud Services	Azure Functions, Azure SignalR
Version Control	Git & GitHub
🚀 How to Run the Web App Locally
Step 1: Clone the Repository
bash
Copy
Edit
git clone https://github.com/casbyhexer/KhumaloCraft_ECOM_CLDV6211POE.git
cd KhumaloCraft_ECOM_CLDV6211POE
Step 2: Navigate to the Part 2 (Web App) Branch
bash
Copy
Edit
git checkout Part2
Step 3: Open the Project in Visual Studio
Ensure all dependencies are installed.
Step 4: Update SQL Server Connection String
Edit the appsettings.json file:

json
Copy
Edit
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=KhumaloCraftDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Step 5: Apply Pending Migrations
powershell
Copy
Edit
dotnet ef database update
Step 6: Run the Application
powershell
Copy
Edit
dotnet run
📦 Running Order Processing with Azure Durable Functions
Step 1: Navigate to the Part 3 (Order Processing) Branch
bash
Copy
Edit
git checkout Part3
Step 2: Open the OrderProcessingFunctionApp in Visual Studio
Ensure Azure Functions Core Tools is installed.
Step 3: Install Azure Functions Core Tools
powershell
Copy
Edit
npm install -g azure-functions-core-tools@4 --unsafe-perm true
Step 4: Run the Azure Function Locally
powershell
Copy
Edit
func start
Step 5: Test the Order Processing API
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
📧 Email: [Your Email]
🌐 GitHub: @casbyhexer

🚀 Happy Coding & Crafting! 🚀
