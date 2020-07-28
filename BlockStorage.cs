using System;
using System.Collections.Generic;
using System.IO;

namespace DBProj {
    public class BlockStorage : IBlockStorage {

        readonly Stream stream;
        readonly int blockSize;
        readonly int blockHeaderSize;
        readonly int blockContentSize;
        readonly int unitOfWork;
        readonly Dictionary<uint, Block> blocks = new Dictionary<uint, Block>();


        public int BLockSize {
            get {
                return blockSize;
            }
        }

        public int BlockHeaderSize {
            get {
                return blockHeaderSize;
            }
        }

        public int blockContentSize{
            get {
                return blockContentSize;
            }
        }

        //// Constructor
        public BlockStorage(Stream storage, int blockSize = 40960, int blockHeaderSize = 48) {
            if (storage == null) {
                throw new ArgumentNullException("storage");
            }

            if (blockHeaderSize >= blockSize) {
                throw new ArgumentException ("blockheaderSize cannot be larger than or equal to blockSize");
            }

            if (blockSize < 128) {
                throw new ArguementException ("blockSize too small");
            }

            this.unitOfWork = ((blockSize >= 4096) ? 4096 : 128);
            this.blockSize = blockSize;
            this.blockHeaderSize = blockHeaderSize;
            this.blockContentSize = blockSize - blockHeaderSize;
            this.stream = storage;   
        }


        //// Public methods
        public IBlock Find (uint blockId) {
                if (true == blocks.ContainsKey(blockId)) {
                    return blocks[blockId];
                }
        }
    }
}

