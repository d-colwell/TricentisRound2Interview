# CorpCorp Box Decisioning Algorithm

## Assumptions

 - There is the potential that the order in which you process the boxes will change the outcome. In these situations, process higher ranked boxes first.
 - File validation is not required.
 - The algorithm prefers time to storage/memory consumption.
 - Comments on `class` and public properties are not required for now. 

## Overview

### Load Files

Use 3rd party tools to amke the process simple, I mean when dealing with data formats.

Also hope async IO helps.

### Jaqard Index

I was hoping classes from `System.Drawing` namespace help with calculations, but it turns the benefit is only from calculating intersection.

### Initial sorting based on Rank

See [HighRankFirstComparer.cs](./BoxCorp.App/HighRankFirstComparer.cs) , order Boxes by ranks desending.

### Real Rank Sorting

See [RealRankComparer.cs](./BoxCorp.App/RealRankComparer.cs) , it has a list of suppressed box Ids.

When modeling boxes, I added an extra propery `Id`, which is unique for all boxes to speed up removal.

### The Orchestration 

See [BoxDecisioning.cs](./BoxCorp.App/BoxDecisioning.cs). It ignores boxes with low ranks when boxes are being pushed to it.
It maintains two lists to speed up removal proces and real rank calculation.

[SortedList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-5.0#remarks) is selected.

## Testing

[FluentAssertions](https://github.com/fluentassertions/fluentassertions) is employed to make tests more readable.

### What can be improved

 - Remove depdency on `Rectangle` to make Box.cs cleaner since the only benefit is calculating intersection.
 - Experiment different sorting classes to see which performs better overall with more files. This is alreay more v2 implementation.

