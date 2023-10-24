namespace MikroPicDesigns.FSMCompiler.v2.Model {

    public interface IVisitable {

        void AcceptVisitor(IVisitor visitor);
    }
}
