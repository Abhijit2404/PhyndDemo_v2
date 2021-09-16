using System.Collections.Generic;
using PhyndDemo_v2.Helpers;

namespace PhyndDemo_v2.Services{

    public interface IProgramRepository{

        IEnumerable<Model.Program> GetPrograms();
        Model.Program GetProgram(int Id);
        void AddProgram(Model.Program Program);
        void DeleteProgram(Model.Program Program);
        IEnumerable<Model.Program> GetPrograms(programParams ProgramParams);
        bool Save();
    }
}