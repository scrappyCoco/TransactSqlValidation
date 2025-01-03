using System;

namespace Coding4Fun.TransactSql.Analyzers;

/// <summary>
/// Exception, occurred during validation of SQL code.
/// </summary>
/// <param name="message">Error message.</param>
public class SqlValidationException(string message) : Exception(message);