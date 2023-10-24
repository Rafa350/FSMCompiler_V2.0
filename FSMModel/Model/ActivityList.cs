namespace MikroPicDesigns.FSMCompiler.v2.Model {

    public sealed class ActivityList: List<Activity> {

        public ActivityList() {

        }

        public ActivityList(IEnumerable<Activity> activities) :
            base(activities) {

        }
    }
}
