# DittoProcessors

## Installing

Install via nuget ``` install-package Gibe.DittoProcessors ```

## Processors
| Processor | Description |
|:----------|:------------|
|ArchetypeStringList| Output archetype content as IEnumerable of string |
|CanonicalUrl| Return the canonical url of the current IPublishedContent as a string |
|Children| Return the children of ```docttypeAlias``` as IEnumerable of string |
|ContentPicker| Return the IPublishedContent linked to by the content picker |
|FilePicker| Return the selected file as MediaFileModel |
|GetPreValueAsString| |
|Grid| Return the grid as GridContentModel |
|ImagePicker| Return the selected image as MediaImageModel |
|Json| Return the object as a JSON |
|LinkPicker| Return the link picker data type data as LinkPickerModel |
|MetaSEO| Return the Meta SEO data type data as MetaModel |
|MultiNodeTreePicker| Return the selected nodes as IEnumerable of IPublishedContent |
|MultipleImagePicker| Return the selected images as IEnumerable of MediaImageModel |
|Navigation| Return the Navigation |
|RelatedLinks| Return related links as ```RelatedLinkModel``` |
|Skip| Return an enumerable of IPublishedContent after skipping the given number of elements |
|Sort| Return an enumerable of IPublishedContent after sorting by ascending order on a given Umbraco property |
|SortDescending| Return an enumerable of IPublishedContent after sorting by descending order on a given Umbraco property |
|Take| Return an enumerable of IPublishedContent after taking the given number of elements |
|Tags| Return tags as IEnumerable of int |
|Url| Return the Url of an IPublishedContent |
|UserPicker| Return the selected user as IUser |
|VideoPicker| Return the Url of an IPublishedContent |

# DittoServices

Install via nuget ``` install-package Gibe.DittoProcessors ```