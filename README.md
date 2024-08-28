# ROE Course Regisration System

## Getting Started

### Prereqiisites

- Docker 27.1
- .NET SDK 8.0
- A running SQL Server

### Installation

1. Clone the repository.

   ```sh
   git clone https://github.com/240708-NET/P3-Team1.git
   ```

2. Create a file `appsettings.json` with the following content and put it into `P3-Team1/UniversityAPI/src`. Remember to replace `<CONNECTION_STRING>` with your SQL Server's connection string.

   ```json
   {
     "ConnectionStrings": {
       "BloggingDatabase": "<CONNECTION_STRING>"
     }
   }
   ```

3. Run the database migrations

   ```sh
   cd P3-Team1/UniversityAPI/src
   dotnet ef database update
   ```

4. Edit `P3-Team1/Frontend/.env` and replace its content with the following.

   ```sh
   VITE_API_BASE=http://localhost:7262/api
   ```

### Usage

1. Create and start the containers

   ```sh
   cd P3-Team1
   docker compose up
   ```

2. Visit `http://localhost/login` and create a ROE account.

3. Login with your account and start register courses.
