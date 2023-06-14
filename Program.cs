using ConsoleApp1.Validator;
using SpiderRobotBAL;
using System;
using Unity;
using Unity.Resolution;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objUnity = RegisterUnityContainer();
            string wallTopOrientation;
            string spiderCurrentLocation;
            string moveInstruction;
            IInputValidator inputValidator;

            do
            {
                Console.WriteLine("Wall Size (Top Right):");
                wallTopOrientation = Console.ReadLine();
                inputValidator = objUnity.Resolve<InputValidator>();
            } while (!inputValidator.ValidateWallInput(wallTopOrientation));

            do
            {
                Console.WriteLine("Spider's Current Location and Orientation:");
                spiderCurrentLocation = Console.ReadLine();
            } while (!inputValidator.ValidateSpiderInput(spiderCurrentLocation));

            do
            {
                Console.WriteLine("Instruction to the Spider to Explore the Wall:");
                moveInstruction = Console.ReadLine();
            } while (!inputValidator.ValidateInstruction(moveInstruction));


            IMovementProcessor objMovementProcessor = objUnity.Resolve<SpiderRoboMovement>(new ResolverOverride[]
                {
                    new ParameterOverride("wallSize", wallTopOrientation.Trim()),
                    new ParameterOverride("spiderRoboPosition",spiderCurrentLocation.Trim())

                });
            string[] finalPosition = objMovementProcessor.ProcessAction(moveInstruction.Trim());

            if (finalPosition[0] == "Success")
            {
                Console.WriteLine("\nOutPut\n");
                Console.WriteLine("Final Position of Spider Robo is: " + (finalPosition[1]) + " " + (finalPosition[2]) + " " + (finalPosition[3]) + " ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(finalPosition[1]);
                Console.ReadKey();
            }
        }

        static IUnityContainer RegisterUnityContainer()
        {
            IUnityContainer objUnity = new UnityContainer();
            objUnity.RegisterType<IMovementProcessor, SpiderRoboMovement>();
            objUnity.RegisterType<IInputValidator, InputValidator>();
            return objUnity;
        }
    }
}
