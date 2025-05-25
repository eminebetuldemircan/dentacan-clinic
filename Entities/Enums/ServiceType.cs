using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
  
        public enum ServiceType
    {
        [Display(Name = "Diş Beyazlatma")]
        ToothWhitening = 1,

        [Display(Name = "Estetik Diş Hekimliği")]
        AestheticDentistry = 2,

        [Display(Name = "İmplant Tedavisi")]
        ImplantTreatment = 3,

        [Display(Name = "Ortodonti (Diş Teli Tedavisi)")]
        Orthodontics = 4,

        [Display(Name = "Ağız, Diş ve Çene Cerrahisi")]
        OralAndMaxillofacialSurgery = 5,

        [Display(Name = "Periodontoloji (Diş Eti Hastalıkları)")]
        Periodontology = 6,

        [Display(Name = "Pedodonti (Çocuk Diş Hekimliği)")]
        Pedodontics = 7,

        [Display(Name = "Endodonti (Kanal Tedavi)")]
        Endodontics = 8,

        [Display(Name = "Konservatif Diş Tedavisi")]
        ConservativeTreatment = 9,

        [Display(Name = "Oral Diagnoz ve Radyoloji")]
        OralDiagnosisAndRadiology = 10,

        [Display(Name = "Genel Anestezi ve Sedasyon")]
        GeneralAnesthesiaAndSedation = 11,

        [Display(Name = "Acil Tedavi")]
        EmergencyTreatment = 12
    }

}
