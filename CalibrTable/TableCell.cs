namespace CalibrTable
{
    public class TableCell<TSource, TValue> where TSource: struct 
        where TValue: struct
    {
        public TSource Source;
        public TSource OldSource;
        public TSource FirstSource;
        public int Count;
        public bool StopStudy;
        public TValue StudyValue;
        public TValue Value;

        private TValue error;
        public TValue Error
        {
            get { return error; }
            set
            {
                E_2 = E_1;
                E_1 = error;
                error = value;                
            }
        }

        public int Tag { get; set; }

        public TValue E_1 { get; internal set; }
        public TValue E_2 { get; internal set; }        
    }
}
