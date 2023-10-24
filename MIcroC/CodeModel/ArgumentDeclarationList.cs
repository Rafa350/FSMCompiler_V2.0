namespace MicroCompiler.CodeModel {

    public sealed class ArgumentDeclarationList: List<ArgumentDeclaration> {

        public ArgumentDeclarationList() {
        }

        public ArgumentDeclarationList(IEnumerable<ArgumentDeclaration> arguments) :
            base(arguments) {
        }

        public ArgumentDeclarationList(params ArgumentDeclaration[] arguments) :
            base(arguments) {
        }
    }
}
