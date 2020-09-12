import React from 'react';
import { Snackbar } from '@material-ui/core';
import MuiAlert from '@material-ui/lab/Alert';
import { useRecoilState } from 'recoil';
import toastState from '../../atom/state/toastState';

function Alert(props) {
    return <MuiAlert elevation={6} variant="filled" {...props} />;
  }

export default function () {
    const [rState, setRState] = useRecoilState(toastState);
    const handleClose = () => {
        if (rState.callback)
            rState.callback();
        setRState({ ...rState, open: false, message: '', callback: null });
    }

    return (<Snackbar open={rState.open} autoHideDuration={rState.autoHideDuration} onClose={handleClose}>
        <Alert onClose={handleClose} severity={rState.severity} >
            {rState.message}
        </Alert>
    </Snackbar>);
}
