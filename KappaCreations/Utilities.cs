﻿using KappaCreations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using static KappaCreations.Constants;

namespace KappaCreations
{
    /// <summary>
    /// Contains general methods for the whole project.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Returns a readable string report of a <see cref="DbEntityValidationException"/>.
        /// </summary>
        /// <param name="exception">The exception instance.</param>
        /// <returns>The formated string of the exception.</returns>
        public static string FormatDbEntityValidationException(
            DbEntityValidationException exception)
        {
            var sb = new StringBuilder();

            sb.Append("DbEntityValidationException. ");
            foreach (var result in exception.EntityValidationErrors)
            {
                string entity = result.Entry.Entity.GetType().Name;
                var errors = new List<string>();

                sb.Append(entity + ": ");
                foreach (var error in result.ValidationErrors)
                {
                    string property = error.PropertyName;
                    string message = error.ErrorMessage;

                    errors.Add($"{property} - {message}");
                }
                sb.Append(string.Join(", ", errors) + ". ");
            }
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Returns a readable string report of a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <param name="exception">The exception instance.</param>
        /// <returns>The formated string of the exception.</returns>
        public static string FormatDbUpdateException(DbUpdateException exception)
        {
            var sb = new StringBuilder();

            sb.Append("DbUpdateException. ");
            foreach (var entry in exception.Entries)
            {
                string entity = entry.Entity.GetType().Name;
                string state = entry.State.ToString();
                var result = entry.GetValidationResult();
                var errors = new List<string>();

                sb.Append($"{entity} in state {state}");
                foreach (var error in result.ValidationErrors)
                {
                    string property = error.PropertyName;
                    string message = error.ErrorMessage;

                    errors.Add($"{property} - {message}");
                }
                if (errors.Count > 0)
                {
                    sb.Append(" has the following errors: ");
                    sb.Append(string.Join(", ", errors));
                    sb.Append(". ");
                }
                else
                {
                    sb.Append(".");
                }
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Returns a <see cref="ProductCategory"/> by id.
        /// </summary>
        /// <param name="id">The position of the <see cref="ProductCategory"/> on the array.</param>
        /// <returns>The instance of the <see cref="ProductCategory"/></returns>
        public static ProductCategory GetProductCategory(int id)
            => PRODUCT_CATEGORIES[id];
        /// <summary>
        /// Returns a <see cref="ProductCategory"/> by category title.
        /// </summary>
        /// <param name="title">The the title of the <see cref="ProductCategory"/></param>
        /// <returns>The instance of the <see cref="ProductCategory"/>
        /// or <see langword="null"/> if not found.</returns>
        public static ProductCategory GetProductCategory(string title)
            => PRODUCT_CATEGORIES.FirstOrDefault(c => c.Title == title) ?? null;
    }
}