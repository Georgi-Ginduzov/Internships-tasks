using ICSharpCode.Decompiler.Util;
using SpaceShuttleLaunch.Utilities.Messages;
using System.Reflection;

namespace SpaceShuttleLaunch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            //IEngine engine = new SpaceMissionEngine();
            //engine.Run();

            var resourceWriter = new ResXResourceWriter("C:\\Users\\Asus\\source\\repos\\Internships-tasks\\HitachiSpaceProgram\\SpaceShuttleLaunch\\Localization\\Resources\\Resources.resx");

            var exceptionMessagesType = typeof(ExceptionMessages);
            var fields = exceptionMessagesType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var field in fields)
            {
                if (field.IsLiteral && !field.IsInitOnly)
                {
                    var key = field.Name;
                    var value = (string)field.GetRawConstantValue();
                    resourceWriter.AddResource(key, value);
                }
            }

            resourceWriter.Generate();
            resourceWriter.Close();
        }
    }
}
