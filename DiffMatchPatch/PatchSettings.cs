namespace DiffMatchPatch
{
    public struct PatchSettings
    {
        /// <summary>
        /// When deleting a large block of text (over ~64 characters), how close
        /// do the contents have to be to match the expected contents. (0.0 =
        /// perfection, 1.0 = very loose).  Note that Match_Threshold controls
        /// how closely the end points of a delete need to match.
        /// </summary>
        public float PatchDeleteThreshold { get; }

        /// <summary>
        /// Chunk size for context length.
        /// </summary>
        public short PatchMargin { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="patchDeleteTreshold"> How far to search for a match (0 = exact location, 1000+ = broad match).
        /// A match this many characters away from the expected location will add
        /// 1.0 to the score (0.0 is a perfect match).</param>
        /// <param name="patchMargin">Chunk size for context length.</param>
        public PatchSettings(float patchDeleteTreshold, short patchMargin)
        {
            PatchDeleteThreshold = patchDeleteTreshold;
            PatchMargin = patchMargin;
        }

        public static PatchSettings Default { get; } = new PatchSettings(0.5f, 4);
    }
}