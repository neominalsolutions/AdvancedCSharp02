using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp02
{
  public class Sample:Object
  {
    public string Name { get; set; }
   

    /// <summary>
    /// Nesnenin referanslarını kopartıp içindeki değerleri clonelamış oluyor. Prototype Design pattern çıkış noktası
    /// </summary>
    /// <returns></returns>
    public Sample getClone()
    {
      return (Sample)this.MemberwiseClone();
    }

  }
}
