using TinyCsvParser.Mapping;

namespace Covid19.Web.Areas.Dashboard.Models
{
    public class CsvQuarantineMapping : CsvMapping<QuarantineViewModel>
    {
        public CsvQuarantineMapping():base()
        {
            this.MapProperty(0, x => x.Munisipio);
            this.MapProperty(1, x => x.KuarentenaObrigatorio);
            this.MapProperty(2, x => x.AutoKuarentena);
            this.MapProperty(3, x => x.PassaQuarentena);
            //this.MapProperty(4, x => x.Total);
        }
    }
}
