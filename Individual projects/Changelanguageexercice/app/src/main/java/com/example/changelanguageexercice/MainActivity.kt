package com.example.changelanguageexercice

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.FloatingActionButton
import androidx.compose.material3.Icon
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.example.changelanguageexercice.ui.theme.ChangeLanguageExerciceTheme

@OptIn(ExperimentalMaterial3Api::class)
class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            ChangeLanguageExerciceTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ){
                    Scaffold (floatingActionButton = {
                        FloatingActionButton(onClick = { /*TODO*/ }) {
                            Icon(imageVector = Icons.Default.Add, contentDescription = null, tint = MaterialTheme.colorScheme.onPrimaryContainer)
                        }
                    }){values ->
                        LazyColumn(contentPadding = values) {
                            items(20) {
                                ImageCard(
                                    title = getString(R.string.cool_picture),
                                    description = getString(R.string.lorem_ipsum),
                                    modifier = Modifier.padding(16.dp)
                                )
                            }
                    }
                }
            }
        }
    }
}}
