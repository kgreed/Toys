using System.Collections.Generic;
using DevExpress.ExpressApp;

namespace Toys.Module.BusinessObjects
{
    public interface INonPersistent
    {
        List<INonPersistent> GetData(IObjectSpace space);


        void NPOnSaving(IObjectSpace persistentOs);
        string SearchText { get; set; }
        int Id { get; set; }
        int CacheIndex { get; set; }
    }
}