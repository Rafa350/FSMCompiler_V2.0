namespace MicroCompiler.CodeModel {

    public sealed class ClassMemberList: List<IClassMember> {

        public ClassMemberList() {
        }

        public ClassMemberList(IEnumerable<IClassMember> members) :
            base(members) {
        }

        public ClassMemberList(params IClassMember[] members) :
            base(members) {
        }
    }
}
