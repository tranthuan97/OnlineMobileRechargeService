export const actionCreators = {
    increment: () => ({ type: 'INCREMENT_COUNT' }),
    decrement: () => ({ type: 'DECREMENT_COUNT' })
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer = (state, incomingAction) => {
    if (state === undefined) {
        return { count: 0 };
    }

    const action = incomingAction;
    switch (action.type) {
        case 'INCREMENT_COUNT':
            return { count: state.count + 1 };
        case 'DECREMENT_COUNT':
            return { count: state.count - 1 };
        default:
            return state;
    }
};
