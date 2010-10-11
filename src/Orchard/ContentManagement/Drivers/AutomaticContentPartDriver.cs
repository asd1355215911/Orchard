namespace Orchard.ContentManagement.Drivers {
    public abstract class AutomaticContentPartDriver<TPart> : ContentPartDriver<TPart> where TPart : ContentPart, new() {
        protected override string Prefix {
            get {
                return (typeof (TPart).Name);
            }
        }

        protected override DriverResult Display(TPart part, string displayType, dynamic shapeHelper) {
            return ContentPartTemplate(part);
        }
        
        protected override DriverResult Editor(TPart part, dynamic shapeHelper) {
            return ContentPartTemplate(part);
        }
        
        protected override DriverResult Editor(TPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return ContentPartTemplate(part);
        }
    }
}