import { CART_ADD_PRODUCT } from "../constants/actionTypes";

const initialState ={
    list: [], //товари в кошику
    count: 0 //кількість товарів в кошику
}

const cartReducer = (state = initialState, action) => {
    const {type, payload} = action;
    switch(type) {
        case CART_ADD_PRODUCT: {
            return {
                ...state,
                payload
            };
        } 
        default: {
            return state;
        }
    }


}

export default cartReducer; 