namespace PorteCaseStudy.Data
{
    using System.ComponentModel.DataAnnotations;

    public class PackageEntity
    {
        [Key]
        public long BoxId { get; set; }

        public int Weight { get; set; }

        public int PartCount { get; set; }
    }
}
