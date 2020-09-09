import React, { useState } from 'react';
import { TextField } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import strings from './../../core/strings';
import logoImage from './../../assets/images/logo.png';

const Authorization = () => {
    const [mobileNumber, setMobileNumber] = useState({
        value: '',
        error: false,
        errorMessage: ''
    });
    const [ruleAgreement, setRuleAgreement] = useState(false);
    const [verifyCode, setVerifyCode] = useState({
        value: '',
        error: false,
        errorMessage: ''
    });

    return (
        <div id='page-auth'>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <div className='flex-center'>
                        <img src={logoImage} alt='logo image' />
                    </div>
                </Grid>

                <Grid item xs={12} sm={3} md={4}></Grid>
                <Grid item xs={12} sm={6} md={4}>
                    <div className="form-group">
                        <TextField
                            error={mobileNumber.error}
                            id="mobileNumber"
                            name="mobileNumber"
                            placeholder="9xxxxxxxxx"
                            label={strings.mobileNumber}
                            value={mobileNumber.value}
                            onChange={(e) => setMobileNumber({ value: e.target.value, error: false, errorMessage: '' })}
                            helperText={mobileNumber.errorMessage}
                            style={{ fontFamily: 'iransans' }}
                            variant="outlined"
                        />
                    </div>
                </Grid>
            </Grid>
        </div>
    );
}
export default Authorization;