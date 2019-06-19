using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using Toys.Module.BusinessObjects;

namespace Toys.Module.Controllers
{
    // https://documentation.devexpress.com/eXpressAppFramework/115672/Task-Based-Help/Business-Model-Design/Non-Persistent-Objects/How-to-Perform-CRUD-Operations-with-Non-Persistent-Objects
    public partial class NonPersistentController : ViewController
    {
        private static List<INonPersistent> objectsCache;

        static NonPersistentController()
        {
        }
        public NonPersistentController()
         : base()
        {

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
                    ((INonPersistent)obj).NPOnSaving(persistentOS);
                }
            }
            persistentOS.CommitChanges();

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
                var persistentOS = nonPersistentObjectSpace.AdditionalObjectSpaces.FirstOrDefault();
                if (persistentOS != null)
                {
                    nonPersistentObjectSpace.AdditionalObjectSpaces.Remove(persistentOS);
                    persistentOS.Dispose();
                }
            }
            base.OnDeactivated();
        }
    }
}
