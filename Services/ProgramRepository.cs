using System;
using System.Collections.Generic;
using System.Linq;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Helpers;

namespace PhyndDemo_v2.Services{

    public class ProgramRepository : IProgramRepository
    {
        private readonly phynd2Context _context;
        public ProgramRepository(phynd2Context context)
        {
            _context = context;
        }

        public void AddProgram(Model.Program Program)
        {
            if (Program == null)
            {
                throw new ArgumentNullException(nameof(Program));
            }

            _context.Programs.Add(Program);
        }

        public void DeleteProgram(Model.Program Program)
        {
            if (Program == null)
            {
                throw new ArgumentNullException(nameof(Program));
            }

            _context.Programs.Remove(Program);
        }

        public Model.Program GetProgram(int Id)
        {
            return _context.Programs.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<Model.Program> GetPrograms()
        {
            return _context.Programs.ToList<Model.Program>();
        }

        public IEnumerable<Model.Program> GetPrograms(programParams ProgramParams)
        {
            if(ProgramParams == null){
                throw new ArgumentNullException(nameof(ProgramParams));
            }

            if(string.IsNullOrWhiteSpace(ProgramParams.sortByName)
                && string.IsNullOrWhiteSpace(ProgramParams.Search))
            {
                return GetPrograms();
            }

            var collection = _context.Programs as IQueryable<Model.Program>;
            if(!string.IsNullOrWhiteSpace(ProgramParams.sortByName))
            {
                var Name = ProgramParams.sortByName.Trim();
                collection = collection.Where(a => a.Name == Name);
            }

            if(!string.IsNullOrWhiteSpace(ProgramParams.Search))
            {
                var search = ProgramParams.Search.Trim();
                return collection.Where(a => a.Name.Contains(search));
            }

            return collection.ToList();
        }

        public bool ProgramExists(int Id)
        {
            return _context.Programs.Any(a => a.Id == Id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}