﻿using System.Text;
using MicroCompiler.CodeGenerator.C;
using MicroCompiler.CodeModel;
using MikroPicDesigns.FSMCompiler.v2.Model;


namespace MikroPicDesigns.FSMCompiler.v2.Generator.C {

    public sealed class CGenerator: GeneratorBase {

        private readonly CGeneratorOptions options;

        public CGenerator(GeneratorParameters generatorParameters) {

            CGeneratorOptions options = new CGeneratorOptions();
            generatorParameters.Populate(options);
            this.options = options;
        }

        public override void Generate(Machine machine) {

            UnitDeclaration unit = MachineUnitGenerator.Generate(machine, options);

            if (String.IsNullOrEmpty(options.OutputType) || (options.OutputType == "MachineHeader")) {
                string header = HeaderGenerator.Generate(unit);
                GenerateMachineHeader(header);
            }

            if (String.IsNullOrEmpty(options.OutputType) || (options.OutputType == "MachineCode")) {
                string code = CodeGenerator.Generate(unit);
                GenerateMachineCode(code);
            }
        }


        /// <summary>
        /// \brief Genera el fitxer de codi de la maquina d'estat.
        /// </summary>
        /// <param name="code">La maquina.</param>
        /// 
        private void GenerateMachineCode(string code) {

            using (StreamWriter writer = File.CreateText(options.MachineCodeFileName)) {

                var sb = new StringBuilder();

                sb
                    .AppendLine("// -----------------------------------------------------------------------")
                    .AppendLine("// Generated by FsmCompiler v1.1")
                    .AppendLine("// Finite state machine compiler tool")
                    .AppendLine("// Copyright 2015-2018 Rafael Serrano (rsr.openware@gmail.com)")
                    .AppendLine("//")
                    .AppendLine("// Warning. Don't touch. Changes will be overwritten!")
                    .AppendLine("//")
                    .AppendLine("// -----------------------------------------------------------------------")
                    .AppendLine()
                    .AppendLine();

                if (!String.IsNullOrEmpty(options.MachineHeaderFileName)) {
                    sb
                        .AppendFormat("#include \"{0}\"", options.MachineHeaderFileName)
                        .AppendLine()
                        .AppendLine()
                        .AppendLine();
                }

                sb
                    .AppendLine(code);

                writer.Write(sb.ToString());
            }
        }

        /// <summary>
        /// \brief Genera el fitxer de codi de la maquina d'estat.
        /// </summary>
        /// <param name="code">La maquina.</param>
        /// 
        private void GenerateMachineHeader(string header) {

            string guardString = Path.GetFileName(options.MachineHeaderFileName).ToUpper().Replace(".", "_");

            using (StreamWriter writer = File.CreateText(options.MachineHeaderFileName)) {

                var sb = new StringBuilder();

                sb
                    .AppendLine("// -----------------------------------------------------------------------")
                    .AppendLine("// Generated by FsmCompiler v1.1")
                    .AppendLine("// Finite state machine compiler tool")
                    .AppendLine("// Copyright 2015-2020 Rafael Serrano (rsr.openware@gmail.com)")
                    .AppendLine("//")
                    .AppendLine("// Warning. Don't touch. Changes will be overwritten!")
                    .AppendLine("//")
                    .AppendLine("// -----------------------------------------------------------------------")
                    .AppendLine()
                    .AppendFormat("#ifndef __{0}__", guardString).AppendLine()
                    .AppendFormat("#define __{0}__", guardString).AppendLine()
                    .AppendLine()
                    .AppendLine();

                if (!String.IsNullOrEmpty(options.IncludeFileName))
                    sb
                        .AppendFormat("#include \"{0}\"", options.IncludeFileName).AppendLine()
                        .AppendLine()
                        .AppendLine();

                sb
                    .AppendLine(header)
                    .AppendLine()
                    .AppendFormat("#endif // __{0}__", guardString).AppendLine();

                writer.Write(sb.ToString());
            }
        }
    }
}