using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;
using ListView = DevExpress.ExpressApp.ListView;

namespace Toys.Module.Controllers
{
    // https://documentation.devexpress.com/eXpressAppFramework/115672/Task-Based-Help/Business-Model-Design/Non-Persistent-Objects/How-to-Perform-CRUD-Operations-with-Non-Persistent-Objects
    public partial class NonPersistentController : ObjectViewController<ListView, INonPersistent>
    {
        private DevExpress.ExpressApp.Actions.ParametrizedAction parametrizedAction1;
        private IContainer components;
        private static List<INonPersistent> objectsCache;
        private string SearchText;
        static NonPersistentController()
        {
        }
        public NonPersistentController()
         : base()
        {
            InitializeComponent();
            this.TargetObjectType = typeof(INonPersistent);
            
        }
        private void ObjectSpace_CustomRefresh(object sender, HandledEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            LoadObjectsCache(objectSpace);
            objectSpace.ReloadCollection(objectsCache);
        }

        private void NonPersistentObjectSpace_ObjectsGetting(Object sender, ObjectsGettingEventArgs e)
        {
            ITypeInfo info = XafTypesInfo.Instance.FindTypeInfo(e.ObjectType);

            if (!info.Implements<INonPersistent>()) return;
            IObjectSpace objectSpace = (IObjectSpace)sender;
            BindingList<INonPersistent> objects = new BindingList<INonPersistent>
            {
                AllowNew = false,
                AllowEdit = true,
                AllowRemove = false
            };

            LoadObjectsCache(objectSpace);
            foreach (INonPersistent obj in objectsCache)
            {
                objects.Add(objectSpace.GetObject(obj));
            }
            e.Objects = objects;
        }

        private void LoadObjectsCache(IObjectSpace objectSpace)
        {
            var npObj = (INonPersistent)Activator.CreateInstance(View.ObjectTypeInfo.Type);
            npObj.SearchText = SearchText;
            objectsCache = npObj.GetData(objectSpace);
        }

        private void NonPersistentObjectSpace_ObjectGetting(object sender, ObjectGettingEventArgs e)
        {
            if (e.SourceObject is IObjectSpaceLink)
            {
                ((IObjectSpaceLink)e.TargetObject).ObjectSpace = (IObjectSpace)sender;
            }
        }
        private void NonPersistentObjectSpace_ObjectByKeyGetting(object sender, ObjectByKeyGettingEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            foreach (Object obj in objectsCache)
            {
                if (obj.GetType() != e.ObjectType || !Equals(objectSpace.GetKeyValue(obj), e.Key)) continue;
                e.Object = objectSpace.GetObject(obj);
                break;
            }
        }

        private void NonPersistentObjectSpace_Committing(Object sender, CancelEventArgs e)
        {
            IObjectSpace objectSpace = (IObjectSpace)sender;
            var persistentOS = ((NonPersistentObjectSpace)objectSpace).AdditionalObjectSpaces.FirstOrDefault();
            foreach (Object obj in objectSpace.ModifiedObjects)
            {
                if (!(obj is INonPersistent)) continue;
                if (objectSpace.IsNewObject(obj))
                {
                    objectsCache.Add((INonPersistent)obj);
                }
                else if (objectSpace.IsDeletedObject(obj))
                {
                    objectsCache.Remove((INonPersistent)obj);
                }

                else
                {
                    ((NonPersistentObjectSpace)objectSpace).GetObject(obj);
                    //((IXafEntityObject)obj).OnSaving();
                   // ((INonPersistent)obj).NPOnSaving(persistentOS);
                }
            }
            persistentOS.CommitChanges();
           
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            GridListEditor editor = View.Editor as GridListEditor;
            if (editor != null && editor.GridView != null && editor.GridView.FocusedRowHandle >= 0)
                editor.GridView.RefreshRow(editor.GridView.FocusedRowHandle);
        }


        protected override void OnActivated()
        {
            base.OnActivated();
            if (!(ObjectSpace is NonPersistentObjectSpace nonPersistentObjectSpace)) return;
            nonPersistentObjectSpace.ObjectsGetting += NonPersistentObjectSpace_ObjectsGetting;
            nonPersistentObjectSpace.ObjectByKeyGetting += NonPersistentObjectSpace_ObjectByKeyGetting;
            nonPersistentObjectSpace.ObjectGetting += NonPersistentObjectSpace_ObjectGetting;
            nonPersistentObjectSpace.Committing += NonPersistentObjectSpace_Committing;
            var persistentOS = this.Application.CreateObjectSpace(typeof(Toy));
            nonPersistentObjectSpace.AdditionalObjectSpaces.Add(persistentOS);
            ObjectSpace.CustomRefresh += ObjectSpace_CustomRefresh;
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            View.CreateCustomCurrentObjectDetailView += NonPersistentController_CreateCustomCurrentObjectDetailView;

           
            ObjectSpace.Refresh();
        }
        protected override void OnDeactivated()
        {
            if (ObjectSpace is NonPersistentObjectSpace nonPersistentObjectSpace)
            {
                nonPersistentObjectSpace.ObjectsGetting -= NonPersistentObjectSpace_ObjectsGetting;
                nonPersistentObjectSpace.ObjectByKeyGetting -= NonPersistentObjectSpace_ObjectByKeyGetting;
                nonPersistentObjectSpace.ObjectGetting -= NonPersistentObjectSpace_ObjectGetting;
                nonPersistentObjectSpace.Committing -= NonPersistentObjectSpace_Committing;
                ObjectSpace.CustomRefresh -= ObjectSpace_CustomRefresh;
                View.CreateCustomCurrentObjectDetailView -= NonPersistentController_CreateCustomCurrentObjectDetailView;
                var persistentOS = nonPersistentObjectSpace.AdditionalObjectSpaces.FirstOrDefault();
                if (persistentOS != null)
                {
                    nonPersistentObjectSpace.AdditionalObjectSpaces.Remove(persistentOS);
                    persistentOS.Dispose();
                }
            }
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }
        private void NonPersistentController_CreateCustomCurrentObjectDetailView(object sender, CreateCustomCurrentObjectDetailViewEventArgs e)
        {

            UpdateCacheFromObjectSpace();
        

            var obj = View.CurrentObject as IXafEntityObject;
            var objAsnp = obj as INonPersistent;
            Trace.WriteLine($"objAsNp id:{objAsnp?.Id} index {objAsnp?.CacheIndex}");
            obj?.OnLoaded();
            Trace.WriteLine("");



        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.parametrizedAction1 = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // parametrizedAction1
            // 
            this.parametrizedAction1.Caption = "Text Search";
            this.parametrizedAction1.Category = "RecordsNavigation";
            this.parametrizedAction1.ConfirmationMessage = null;
            this.parametrizedAction1.Id = "TextSearch";
            this.parametrizedAction1.NullValuePrompt = null;
            this.parametrizedAction1.ShortCaption = null;
            this.parametrizedAction1.ToolTip = null;
            this.parametrizedAction1.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.ParametrizedAction1_Execute);
            // 
            // NonPersistentController
            // 
            this.Actions.Add(this.parametrizedAction1);

        }

        private void ParametrizedAction1_Execute(object sender, DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventArgs e)
        {
             SearchText = (String)e.ParameterCurrentValue;
             View.ObjectSpace.Refresh();
        }

        private void UpdateCacheFromObjectSpace() // causes view refresh
        {

            foreach (INonPersistent obj in ObjectSpace.ModifiedObjects)
            {
                var cacheObj = objectsCache.Find(x => x.Id == obj.Id);
                objectsCache[cacheObj.CacheIndex] = obj;
            }


        }
    }
}
