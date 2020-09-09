import React from 'react';
import TextField from '@material-ui/core/TextField';
import { Button } from '@material-ui/core';

const Authorization = () => {
    return (
        <div>
            <TextField
                id="outlined-number"
                label="Number"
                type="text"
                InputLabelProps={{
                    shrink: true,
                }}
                variant="outlined"
            />

            <Button variant="contained" color="primary">
                Disable elevation
            </Button>
        </div>
    );
}
export default Authorization;