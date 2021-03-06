﻿using System;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Represents an x- and y-coordinate point in 2-D grid.
    /// </summary>
    [Serializable]
    public struct GridCell : ICloneable, IEquatable<GridCell>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridCell"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public GridCell(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>
        /// The X.
        /// </value>
        public int X { get; }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>
        /// The Y.
        /// </value>
        public int Y { get; }

        /// <summary>
        /// Determines whether this instance is default.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDefault => this.X == 0 && this.Y == 0;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="gridCell1">The gridCell1.</param>
        /// <param name="gridCell2">The gridCell2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(GridCell gridCell1, GridCell gridCell2)
        {
            return gridCell1.Equals(gridCell2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="gridCell1">The gridCell1.</param>
        /// <param name="gridCell2">The gridCell2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(GridCell gridCell1, GridCell gridCell2)
        {
            return !gridCell1.Equals(gridCell2);
        }

        /// <summary>
        /// Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        public bool Equals(GridCell other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is GridCell cell && this.Equals(cell);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X * 397) ^ this.Y;
            }
        }

        /// <inheritdoc />
        public object Clone()
        {
            return new GridCell(this.X, this.Y);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"X: {this.X}, Y: {this.Y}";
        }

        /// <summary>
        /// To the string short.
        /// </summary>
        /// <returns>Return a short format of x and y.</returns>
        public string ToStringShort()
        {
            return $"{this.X}, {this.Y}";
        }
    }
}