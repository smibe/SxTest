module SExpecto

/// Actual test function
type TestCode = unit -> unit

/// Test tree – this is how you compose your tests as values. Since
/// any of these can act as a test, you can pass any of these DU cases
/// into a function that takes a Test.
type Test =
  /// A test case is a function from unit to unit, that can be executed
  /// by Expecto to run the test code.
  | TestCase of code:TestCode
  /// A collection/list of tests.
  | TestList of tests:Test seq
  /// A labelling of a Test (list or test code).
  | TestLabel of label:string * test:Test

type ExpectoException(msg) = inherit Exception(msg)
type AssertException(msg) = inherit ExpectoException(msg)
type IgnoreException(msg) = inherit ExpectoException(msg)

