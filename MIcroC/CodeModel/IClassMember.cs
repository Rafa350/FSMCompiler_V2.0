﻿namespace MicroCompiler.CodeModel {

    public interface IClassMember: IVisitable {

        AccessSpecifier Access { get; set; }
    }
}
