using MikroPicDesigns.FSMCompiler.v2.Model.Activities;

namespace MikroPicDesigns.FSMCompiler.v2.Model {

    public interface IVisitor {

        void Visit(Action action);
        void Visit(Event ev);
        void Visit(Guard guard);
        void Visit(Machine machine);
        void Visit(State state);
        void Visit(Transition transition);
        void Visit(Variable variable);

        void Visit(InlineActity action);
        void Visit(RunActivity action);
        void Visit(ThrowActivity action);
    }
}
