function callMethod() {
    DotNet.invokeMethodAsync(
        "BlazorServer",
        "GetValueFromMethod"
    ).then(
        result => {
            alert(
                "Message from Result: " + result
            )
        }
    )
}

export function callInstanceMethod(
    instanceObject
) {
    instanceObject.invokeMethodAsync(
        "GetValueFromInstance"
    ).then(
        result => {
            alert(
                "Message from Result: " + result
            )
        }
    )
}