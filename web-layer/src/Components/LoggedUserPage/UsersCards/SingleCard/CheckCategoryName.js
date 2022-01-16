import React from "react";

const CheckCategoryName = (category) =>
{
    if(category === "Roman")
        return 1;
    if(category === "Drama")
        return 2;
    if(category === "Poem")
        return 3;
}
export default CheckCategoryName;