namespace DBProj {
    public class Block : IBlock {
        readonly byte[] firstSector;
        readonly long?[] cachedHeaderValue = new long?[5];
        readonly Stream stream;
        readonly BlockStorage storage;

        bool isFirstSectorDirty = false;
        bool isDisposed = false;
        
        public event EventHandler Disposed;

        public uint Id {
            get {
                return Id;
            }
        }

        

    }
}
