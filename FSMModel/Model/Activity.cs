namespace MikroPicDesigns.FSMCompiler.v2.Model {

    public abstract class Activity: IVisitable {

        public abstract void AcceptVisitor(IVisitor visitor);
    }
}
