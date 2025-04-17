using MudBlazor.Charts;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DemoApplication.Server.Models
{
    public class UserWithRoles
    {
        public string UserId { get; set; }
        public string Full_Name { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool Error { get; set; }
        public bool Saved { get; set; }
        public bool Saving { get; set; }
    }

    public class Admin
    {


        public string AdminID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime? createdOn { get; set; }

    }

    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime? StartDateTime { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime? EndDateTime { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        public string GoogleMapsUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }

        public ICollection<TicketType> TicketTypes { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
    public class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g. "Standard", "VIP"
        public decimal Price { get; set; } // 0 for free tickets
        public int Quantity { get; set; }
        public DateTime? EarlyBirdEndDate { get; set; }
        public decimal? EarlyBirdPrice { get; set; }

        public int EventId { get; set; }
        public EventModel Event { get; set; }
    }

    public class Attendee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsConfirmed { get; set; }

        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }

        public bool IsOnWaitingList { get; set; }
        public string QRCodePath { get; set; }
    }

}
