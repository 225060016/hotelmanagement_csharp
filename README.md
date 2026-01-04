# hotelmanagement_csharp

## Hotel Management System (WPF)

A modern, desktop-based Hotel Management Application built with C#, WPF (Windows Presentation Foundation), and the MVVM (Model-View-ViewModel) architectural pattern.


## Purpose of the Project in Full Scale

The main goal of this project is to modernize hotel management by replacing old-fashioned, complicated tables and spreadsheets with a visual and user-friendly system.

By using the powerful features of WPF, the application provides hotel staff with an intuitive, card-based dashboard. This design makes it much easier to manage room assignments, guest check-ins, and cleaning tasks, even during the busiest hours of the day.

Our focus is to simplify the daily workload of hotel employees, improve communication between the front desk and housekeeping, and provide a solid technical structure that can grow with the hotel's needs.

In full scale, the application would be able to manage even the biggest hotels easily with database connections, real time features, and an authentication system for many workers to use at the same time.

---

## Features in this Demo

- **Housekeeping:** Dedicated status for rooms that "Need Cleaning" after checkout.
- **Filtering:** Filter rooms by type (Suite, Single, Double) or availability.
- **Reservation Management:** Fast guest check-in and automated fee calculation based on daily rates.
- **Activity Logs:** A recent activity sidebar to track the history of bookings and payments.


## Architecture & Class Structure

### Models

- **Room.cs:**  
  Represents the core entity containing room properties and status flags.

- **Booking.cs:**  
  Stores reservation details and historical transaction data.

---

### ViewModels

The logic layer that connects the Data to the UI.

#### MainViewModel.cs

- **RoomsView:**  
  An ICollectionView used for filtering and sorting the room list.

- **ReserveRoomCommand():**  
  Logic to assign a guest to a selected room.

- **CheckOutCommand():**  
  Handles payment calculation and triggers the cleaning status.

#### RoomViewModel.cs

- A wrapper for the Room model to handle UI-specific property change notifications (INotifyPropertyChanged).

- **ToggleOccupancy():**  
  Manages the transition between occupied and available states.

#### BookingViewModel.cs

- **CalculateStayDuration(DateTime checkIn, DateTime checkOut):**  
  Calculates the time difference between dates. It uses Math.Ceiling to ensure even a partial day is billed as a full day.

- **GenerateInvoice(decimal dailyRate):**  
  Multiplies the stay duration by the room's specific rate to create the final billing amount.

- **ArchiveBooking():**  
  Saves the completed transaction into the "Recent Activity" list for record-keeping.
  
---


## Views 

### MainWindow.xaml

- Defines the primary dashboard layout using a Grid system.
- Contains a ListBox with a WrapPanel ItemsPanel for the responsive card-based room display.
- Implements DataTemplates and ControlTemplates for consistent styling of room cards.


### MainWindow.xaml.cs

- **Window_Loaded():**  
  Initializes the primary dashboard and triggers the initial data load.

- **FilterSelection_Changed():**  
  Communicates with the MainViewModel to refresh the filtered view of room cards.

- **BtnAddRoom_Click():**  
  Opens the room addition dialog.


## AddRoomWindow.xaml

- A modal dialog designed for data entry.
- Uses StackPanel and DockPanel for a structured form layout.
- Includes validation-ready input fields for Room Number and Room Type.


## AddRoomWindow.xaml.cs

- **btnSave_Click():**  
  Validates the user input for new rooms and sends the data back to the main collection.

- **btnCancel_Click():**  
  Closes the dialog safely without making any changes to the inventory.
