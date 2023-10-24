using MikroPicDesigns.FSMCompiler.v2.Model;


namespace MikroPicDesigns.FSMCompiler.v2.Generator {

    public abstract class GeneratorBase: IGenerator {

        public virtual void Generate(Machine machine) {

            throw new NotImplementedException();
        }
    }
}
