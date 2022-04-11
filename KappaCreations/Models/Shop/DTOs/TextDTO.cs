﻿using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class TextDTO : IDataTransferObject<Text>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextDTO"/> class.
        /// </summary>
        public TextDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TextDTO"/> class.
        /// </summary>
        /// <param name="design">A <see cref="Text"/> object to be mapped to DTO.</param>
        public TextDTO(Text text)
        {
            Id = text.Id;
            PosX = text.Position.X;
            PosY = text.Position.Y;
            ZIndex = text.Position.Z;
            SizeWidth = text.Size.Width;
            SizeHeight = text.Size.Height;
            ColourRed = text.Colour.Red;
            ColourGreen = text.Colour.Green;
            ColourBlue = text.Colour.Blue;
            ColourAlpha = text.Colour.Alpha;
            Content = text.Content;
            Font = (int)text.Font;
        }

        public int? Id { get; set; }

        // Position
        public double PosX { get; set; } = 0;
        public double PosY { get; set; } = 0;
        public int ZIndex { get; set; }

        // Size
        public double SizeWidth { get; set; } = 100;
        public double SizeHeight { get; set; } = 100;

        // Colour
        public byte ColourRed { get; set; }
        public byte ColourGreen { get; set; }
        public byte ColourBlue { get; set; }
        public double ColourAlpha { get; set; }

        public string Content { get; set; } = string.Empty;
        public int Font { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Text Map() => new Text
        {
            Position = new Position(PosX, PosY, ZIndex),
            Size = new Size(SizeWidth, SizeHeight),
            Colour = new Colour(ColourRed, ColourGreen, ColourBlue, ColourAlpha),
            Content = Content,
            Font = (Font)Font,
        };

        /// <summary>
        /// Maps a <see cref="Text"/> instance to an object that matches the properties of a
        /// <see cref="TextDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="text">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="TextDTO"/>.</returns>
        public static object MapToCamelCase(Text text) => new
        {
            id = text.Id,
            posX = text.Position.X,
            posY = text.Position.Y,
            zIndex = text.Position.Z,
            sizeWidth = text.Size.Width,
            sizeHeight = text.Size.Height,
            colourRed = text.Colour.Red,
            colourGreen = text.Colour.Green,
            colourBlue = text.Colour.Blue,
            colourAlpha = text.Colour.Alpha,
            content = text.Content,
            font = (int)text.Font,
        };
        /// <summary>
        /// Maps a collection of <see cref="Text"/> instances to objects that matche the properties of
        /// <see cref="TextDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="texts">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="TextDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Text> texts)
            => texts.Select(text => MapToCamelCase(text));
    }
}