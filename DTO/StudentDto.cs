namespace ParentTeacherBridge.API.DTO
{
    public class StudentDto
    {

        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public string ProfilePhoto { get; set; } = string.Empty;


        //public int StudentId { get; set; }
        //public string Name { get; set; } = string.Empty;
        //public DateTime Dob { get; set; }
        //public string Gender { get; set; } = string.Empty;
        //public string EnrollmentNo { get; set; } = string.Empty;
        //public string BloodGroup { get; set; } = string.Empty;
        //public string ProfilePhoto { get; set; } = string.Empty;

    }


}
