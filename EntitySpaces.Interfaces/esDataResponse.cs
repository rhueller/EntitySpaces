/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/

using System;
using System.Data;
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

namespace EntitySpaces.Interfaces
{
    /// <summary>
    /// Returned by the EntitySpaces DataProvider in response to a request. 
    /// </summary>
    /// <seealso cref="esDataRequest"/>
    [Serializable] 
    public class esDataResponse
    {
        /// <summary>
        /// The DataTable containing the data. Depending on the type of command
        /// issued against the provider this may or may not be null.
        /// </summary>
        public DataTable Table;

        /// <summary>
        /// Valid when esDataProvider.FillDataSet was called.
        /// </summary>
        public DataSet DataSet;

        /// <summary>
        /// Valid when esDataProvider.ExecuteReader was called.
        /// </summary>
        public IDataReader DataReader;

        /// <summary>
        /// Valid when esDataProvider.ExecuteScalar was called.
        /// </summary>
        public object Scalar;

        /// <summary>
        /// Valid when a EntitySpaces dynamic query has been executed. This is the 
        /// raw sql generated by the query itself.
        /// </summary>
        public string LastQuery;

        /// <summary>
        /// The exception returned by the EntitySpaces DataProvider, if any. See <see cref="IsException"/>
        /// </summary>
        public Exception Exception;

        /// <summary>
        /// The number of rows effected by the command.
        /// </summary>
        public int RowsEffected;

        /// <summary>
        /// Currently not used, but will be when the Asyncronous Commands are added.
        /// </summary>
        public IAsyncResult AsyncResult;

        /// <summary>
        /// The parameters need to carry out the command. May also contain output
        /// parameters.
        /// </summary>
        public esParameters Parameters;

        /// <summary>
        /// True if the <see cref="Exception"/> property is non-null.
        /// </summary>
        public bool IsException => Exception != null;
    }
}
