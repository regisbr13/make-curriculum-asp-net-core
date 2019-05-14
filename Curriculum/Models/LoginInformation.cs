using System;

namespace MakeCurriculum.Models
{
    public class LoginInformation
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public DateTime LoginDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
