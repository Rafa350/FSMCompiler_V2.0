using MikroPicDesigns.FSMCompiler.v2.Model;


namespace MikroPicDesigns.FSMCompiler.v2.Generator {

    public interface IGenerator {

        void Generate(Machine machine);
    }
}
