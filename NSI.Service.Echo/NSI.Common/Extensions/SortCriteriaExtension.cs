﻿using NSI.Common.Collation;
using NSI.Common.Exceptions;
using NSI.Common.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSI.Common.Extensions
{
    public static class SortCriteriaExtension
    {
        /// <summary>
        /// Performs sanity validation of sort criteria. Does not validate if sort criteria object is null.
        /// </summary>
        /// <param name="sortCriteria"><see cref="SortCriteria"/></param>
        public static void ValidateSortCriteria(this SortCriteria sortCriteria)
        {
            if (sortCriteria != null && string.IsNullOrWhiteSpace(sortCriteria.Column))
            {
                throw new NsiArgumentException(ExceptionMessages.SortColumnNameEmpty);
            }
        }
    }
}
