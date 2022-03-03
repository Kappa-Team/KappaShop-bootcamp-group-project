﻿namespace KappaShop.Models
{
    /// <summary>
    /// Represents the width and height of a 2D shape.
    /// </summary>
    struct Size
    {
        /// <summary>
        /// Initializes a new <see cref="Size"/> struct.
        /// </summary>
        /// <param name="size">The size for both the width and height of the 2D shape.</param>
        public Size(float size) => (Width, Height) = (size, size);
        /// <summary>
        /// Initializes a new <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The size of the width and height of the 2D shape.</param>
        /// <param name="height">The size of the height and height of the 2D shape.</param>
        public Size(float width, float height) => (Width, Height) = (width, height);

        /// <summary>
        /// The size of the width and height of the 2D shape.
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// The size of the height and height of the 2D shape.
        /// </summary>
        public float Height { get; set; }
    }
}