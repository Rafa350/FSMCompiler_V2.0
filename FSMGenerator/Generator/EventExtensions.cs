using MikroPicDesigns.FSMCompiler.v2.Model;


namespace MikroPicDesigns.FSMCompiler.v2.Generator {

    public static class EventExtensions {

        public static string GetFullName(this Event ev) {

            if ((ev.Arguments == null) || String.IsNullOrEmpty(ev.Arguments.Expression))
                return ev.Name;
            else
                return String.Format("{0}({1})", ev.Name, ev.Arguments.Expression);
        }
    }
}
