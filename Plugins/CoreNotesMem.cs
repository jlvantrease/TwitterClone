using System.Collections.Generic;

namespace CoreNotes
{
    class CoreNotesMem
    {
        private List<Note> notes;

        public CoreNotesMem()
        {
            this.notes = new List<Note>();
        }

        public CoreNotesMem(List<Note> n)
        {
            this.notes = new List<Note>(n);
        }
    
        public bool Add(Note n)
        {
            int count = this.notes.FindIndex(x => x.ID == n.ID);
            if (count != -1)
            {
                return false;
            }
            this.notes.Add(n);
            return true;
        }

        // The number of elements removed from the Notes list
        public int DeleteByID(int ID)
        {
            return this.notes.RemoveAll(x => x.ID == ID);
        }
    }
}