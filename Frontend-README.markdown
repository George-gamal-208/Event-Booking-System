# Event Booking System - Frontend

## Overview
This is the frontend part of the Event Booking System, built with ASP.NET MVC views and custom CSS. It provides a user-friendly interface for browsing and booking events, with a modern pagination system, custom styling, and a responsive design.

### Features
- **Event Listing**: Displays active events (CurrentState = 1) in a grid layout with 6 events per page.
- **Custom Styling**: Uses `site.css` for a light blue theme (#87CEEB) with gradient pagination buttons.
- **Responsive Design**: Event cards and pagination adapt to different screen sizes.
- **Interactive UI**: Hover effects on event cards, "Book Now" buttons, and pagination buttons.

## Prerequisites
- **.NET 8 SDK**: Ensure the .NET 8 SDK is installed. [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- **Node.js** (optional): Only if you plan to add client-side JavaScript libraries in the future.
- **Browser**: A modern browser (e.g., Chrome, Firefox) to test the UI.

## Setup Instructions
1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd EventBookingSolution
   ```

2. **Navigate to the Project**
   The frontend is part of the `EventBooking.Web` project:
   ```bash
   cd EventBooking.Web
   ```

3. **Install Dependencies**
   The frontend relies on static files (CSS). Ensure the `wwwroot/css/site.css` file is present:
   ```bash
   dotnet restore
   ```

4. **Verify Static Files**
   - Ensure `site.css` is located at `EventBooking.Web/wwwroot/css/site.css`.
   - The `_Layout.cshtml` file loads this CSS: `<link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />`.

5. **Run the Application**
   The frontend is served as part of the ASP.NET MVC app:
   ```bash
   dotnet run --project EventBooking.Web
   ```

## Customization
- **Styling**: Edit `wwwroot/css/site.css` to adjust colors, layouts, or animations.
- **Views**: Modify Razor views in `EventBooking.Web/Views/` (e.g., `Home/Index.cshtml` for the event list).

## Troubleshooting
- **CSS Not Loading**: Ensure `site.css` is in `wwwroot/css/` and `app.UseStaticFiles()` is in `Program.cs`.
- **Styles Not Applied**: Clear browser cache (Ctrl + F5) or check for typos in class names.
- **Responsive Issues**: Test on different screen sizes and adjust `site.css` media queries if needed.