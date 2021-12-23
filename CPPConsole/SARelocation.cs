namespace CPP
{
    public enum SAMoveType { N0, N1, Both, Swap, Slide };
    public class SARelocation
    {

        public int mN0;
        public int mN1;
        public int mC0;
        public int mC1;
        public int mChange;

        public SAMoveType mMoveType;


    }
}
