<div align="center">
    <img alt="coding" width="400" src="https://github.com/tuRjoX/LifeLine-Blood-Bank/blob/master/LifeLine%20Blood%20Bank/Devlopers/Background.png">
</div>


# Lifeline Blood Bank Management System

Lifeline Blood Bank Management System is a C# application built with Microsoft SQL Server, Guna UI, and ReaLTaiizor packages. It allows for efficient blood donation and request management for both general users and admins.

## Features

The system offers different features based on the user role.

### Admin Features:
- **Donor Management:** Add, update, and view donor details.
- **Donation Management:** Add donation records, view available blood stock, and transfer blood.
- **Patient Management:** Add and view patient details.
- **Request Management:** Accept blood requests from general users.

### General User Features:
- **Blood Donation:** Users can donate blood and their details will be saved in the system.
- **Blood Request:** Users can request specific blood types, and the request is sent to the admin for review and acceptance.

## Technologies Used
- **Frontend:**
  - C# (Windows Forms)
  - Guna UI
  - ReaLTaiizor UI Components

- **Backend:**
  - Microsoft SQL Server (Database Management)

## Getting Started

### Prerequisites
- Visual Studio with .NET Framework installed
- Microsoft SQL Server
- Guna UI and ReaLTaiizor packages (can be installed via NuGet Package Manager)

## Contributors
<table>
    <tr>
        <td><img src="https://github.com/tuRjoX/LifeLine-Blood-Bank/blob/master/LifeLine%20Blood%20Bank/Devlopers/1.jpg" alt="TURJO DAS DIP" width="100"></td>
        <td>TURJO DAS DIP<br>ID: 22-48558-3</td>
    </tr>
    <tr>
        <td><img src="https://github.com/tuRjoX/LifeLine-Blood-Bank/blob/master/LifeLine%20Blood%20Bank/Devlopers/2.jpg" alt="SHAILY SAHA" width="100"></td>
        <td>SHAILY SAHA<br>ID: 22-48530-3</td>
    </tr>
    <tr>
        <td><img src="https://github.com/tuRjoX/LifeLine-Blood-Bank/blob/master/LifeLine%20Blood%20Bank/Devlopers/3.jpg" alt="MD. MEHEDI HASAN" width="100"></td>
        <td>MD. MEHEDI HASAN<br>ID: 22-49199-3</td>
    </tr>
    <tr>
        <td><img src="https://github.com/tuRjoX/LifeLine-Blood-Bank/blob/master/LifeLine%20Blood%20Bank/Devlopers/4.jpg" alt="MD. SAIF AHMED SOURAV" width="100"></td>
        <td>MD. SAIF AHMED SOURAV<br>ID: 22-46790-1</td>
    </tr>
</table>

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/your-repo/lifeline-broadband-management.git
    ```
2. Open the solution file in Visual Studio.
3. Restore NuGet packages (Guna UI, ReaLTaiizor).
4. Set up your **SQL Server**:
   - Create a new database.
   - Run the provided SQL scripts to set up tables (Donor, Donation, Patient, BloodStock, BloodRequests, Users, etc.).
5. Update the **app.config** file with your SQL Server connection string.
   ```xml
   <connectionStrings>
     <add name="BloodBankDb" connectionString="Data Source=YOUR_SERVER;Initial Catalog=BloodBankDb;Integrated Security=True" />
   </connectionStrings>
